from dostoevsky.tokenization import RegexTokenizer
from dostoevsky.models import FastTextSocialNetworkModel
import csv

tokenizer = RegexTokenizer()

model = FastTextSocialNetworkModel(tokenizer=tokenizer)
with open("rusentiment_test.csv", encoding='utf-8') as r_file:
    file_reader = csv.reader(r_file, delimiter = ",")
    count = 0
    right = 0
    message = ['']
    for row in file_reader:
        message[0] = row[1]
        result = model.predict(message, k=1)
        prediction = list(result[0].keys())[0]
        if prediction == row[0]:
            right +=1
        count += 1
    print(f"Точность: {round((right/count)*100,2)}%")
