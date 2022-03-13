import time
from sklearn.metrics import accuracy_score
from sklearn.tree import DecisionTreeClassifier
from helperfns import *

X_train, X_test, Y_train, Y_test = pre_processing()

#print(X_test,Y_test)

clf = DecisionTreeClassifier().fit(X_train, Y_train)
filename = 'decisionTree.sav'
pickle.dump(clf, open(filename, 'wb'))
y_pred = clf.predict(X_test)
accuracy = accuracy_score(y_pred, Y_test)
print(accuracy)