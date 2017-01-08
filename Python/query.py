import psycopg2
import os

#conn = psycopg2.connect(database="postgres", user="postgres", port="5432", password="password")
conn = psycopg2.connect(database="postgres", host="/home/" + os.environ['USER'] + "/postgres", port="5432")
print ("Database Connection Succesful")
print ("")
cursor = conn.cursor()

#query 1
numerator = 0
denominator = 0
cursor.execute("SELECT count(*) FROM STUDENT WHERE (SUBJ = 'ABC' OR SUBJ = 'DEF');")
denominator = float(cursor.fetchone()[0])
for i in range(1,21):
    cursor.execute("""SELECT count(*) FROM STUDENT WHERE (SUBJ = 'ABC' OR SUBJ = 'DEF') AND UNITS = %s;""", (str(i),))
    numerator = float(cursor.fetchone()[0])
    percent = (numerator/denominator)*100
    print("attempt " + str(i) + " unit " + str(percent))

print ("")
#query 2
gplist = []
for i in range(1,21):
    cursor.execute("""SELECT GP FROM STUDENT WHERE (SUBJ = 'ABC' OR SUBJ = 'DEF') AND UNITS = %s AND GRADE != 'P' AND GRADE != 'NP' AND GRADE != ' ' AND GRADE != 'S'
    AND GRADE != 'I' AND GRADE != 'IP' AND GRADE != 'NG' AND GRADE != 'NS' AND GRADE != 'U' AND GRADE != 'W04' AND GRADE != 'W10' AND GRADE != 'WD1'
    AND GRADE != 'WD2' AND GRADE != 'WD4' AND GRADE != 'WDC' AND GRADE != 'WI' AND GRADE != 'WN' AND GRADE != 'XR' AND GRADE != 'Y';""", (str(i),))
    for row in cursor.fetchall():
        gplist.append(float(row[0]))
    avg = sum(gplist) / float(len(gplist))
    print("attempt " + str(i) + " unit avg gpa: " + str("{0:.2f}".format(avg)))
    
conn.close()
