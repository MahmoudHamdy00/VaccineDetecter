from flask import Flask ,jsonify , request

import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import LabelEncoder
import pickle
import pandas as pd
from sklearn.metrics import accuracy_score

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



app = Flask(__name__)
@app.route('/<int:Age> <string:Gender> <string:Country> <string:Blood> <int:RedCells> <int:WhiteCells>')
def testing(Age,Gender,Country,Blood,RedCells,WhiteCells):
    data =[Age,Gender,Country,Blood,WhiteCells,RedCells]

    data["Gender"] = feature_encoder(data["Gender"])
    data["Country"] = feature_  encoder(data["Country"])
    data["Blood"] = feature_encoder(data["Blood"])
    data["WhiteCells"] = feature_encoder(data["WhiteCells"])
    data["RedCells"] = feature_encoder(data["RedCells"])
    X = data[['Age', 'Gender', 'Country', 'Blood', 'RedCells', 'WhiteCells']].iloc[:, :]
    X = feature_scaling(X, 0, 100)
    filename = 'decisionTree.sav'
    decisionTree = pickle.load(open(filename, 'rb'))
    y_pred = decisionTree.predict(X)
    return jsonify(y_pred),200
if __name__ == '__main__':
    app.run()