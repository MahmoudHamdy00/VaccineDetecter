from random import randint
import random
import pycountry
import numpy as np
import pandas as pd

final_data = []
genders = ["male", "female"]
bloodTypes = ["O-", "O+", "A+", "A-", "B+", "B-", "AB-", "AB+"]
vaccines = ["Moderna", "Pfizer/BioNTech", "Gamaleya", "Janssen (Johnson & Johnson)", "Strazenka"]

for x in range(100000):
    age = randint(5, 105)
    gender = random.choice(genders)
    country = random.choice(list(pycountry.countries)).name
    bloodType = random.choice(bloodTypes)
    vaccine = random.choice(vaccines)
    final_data.append(np.array([age, gender, country, bloodType,randint(100000000, 1000000000), randint(100000000, 1000000000), vaccine]))

pd.DataFrame(final_data).to_csv("./submission.csv")
