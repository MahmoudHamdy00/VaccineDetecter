import time
from sklearn.metrics import accuracy_score
from sklearn.tree import DecisionTreeClassifier
import pickle
import numpy as np
import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import LabelEncoder




def pre_processing():
    # Read data
    data = pd.read_csv("./submission.csv")

    # Drop rows of blank values
    data.dropna(how='any', inplace=True)

    # Encode features
    data["Gender"] = feature_encoder(data["Gender"])
    data["Country"] = feature_encoder(data["Country"])
    data["Blood"] = feature_encoder(data["Blood"])
    data["Vaccine"] = feature_encoder(data["Vaccine"])

    # Correlation matrix to help us in features selection
    # corr_matrix = data.corr()
    # best_features = corr_matrix.index[abs(corr_matrix['Age']) >0]
    # #best_features = best_features.delete(-1)
    # X = data[best_features]

    # print("Correlation Matrix:\n", corr_matrix)
    # print("-----------------------------------------------------------------------------")

    #corr_matrix.to_csv('Correlation Matrix.csv')

    X = data[['Age', 'Gender', 'Country', 'Blood', 'RedCells', 'WhiteCells']].iloc[:, :]
    X = feature_scaling(X, 0, 100)
    Y = data[['Vaccine']].iloc[:, :]
    Y = feature_scaling(Y, 0, 100)
    Y = Y.flatten()
    X_train, X_test, y_train, y_test = train_test_split(X, Y, test_size=0.20, random_state=1)

    return X_train, X_test, y_train, y_test


def feature_scaling(X, a, b):
    X = np.array(X)
    Normalized_X = np.zeros((X.shape[0], X.shape[1]))
    for i in range(X.shape[1]):
        Normalized_X[:, i] = ((X[:, i] - min(X[:, i])) / (max(X[:, i]) - min(X[:, i]))) * (b - a) + a
    return Normalized_X


def feature_encoder(X):
    lbl = LabelEncoder()
    lbl.fit(list(X.values))
    X = lbl.transform(list(X.values))
    return X


