import csv
import psycopg2
import os

#conn = psycopg2.connect(database="postgres", user="postgres", port="5432", password="password")
conn = psycopg2.connect(database="postgres", host="/home/" + os.environ['USER'] + "/postgres", port="5432")
print ("Database Connection Succesful")
cursor = conn.cursor()

cursor.execute("DROP TABLE IF EXISTS COURSE")
cursor.execute("DROP TABLE IF EXISTS MEETING")
cursor.execute("DROP TABLE IF EXISTS STUDENT")

cursor.execute("CREATE TABLE COURSE( CID varchar, TERM varchar, SUBJ varchar, CRSE varchar, SEC varchar, UNITS varchar);")
cursor.execute("CREATE TABLE MEETING( INSTRUCTOR varchar, TYPE varchar, DAYS varchar, TIME varchar, BUILD varchar, ROOM varchar);")
cursor.execute("CREATE TABLE STUDENT( CID varchar, SUBJ varchar, SEAT varchar, SID varchar, SURNAME varchar, PREFNAME varchar, LEVEL varchar, UNITS varchar, CLASS varchar, MAJOR varchar, GRADE varchar, STATUS varchar, EMAIL varchar, GP varchar);")

quarters = [1,2,3,4]
firstyear = 1989
lastyear = 2012
years = list(range(firstyear,lastyear+1))
files = []
for year in years:
    for quarter in quarters:
        files.append((str(year) + "_Q" + str(quarter)+".csv"))
del files[:2]
del files[-1]
for file in files:
    ifile  = open(file, "r")
    line = csv.reader(ifile, skipinitialspace=True)
    for data in line:
        if data == ['CID', 'TERM', 'SUBJ', 'CRSE', 'SEC', 'UNITS']:
            coursedata = next(line)
            cursor.execute("INSERT INTO COURSE (CID, TERM, SUBJ, CRSE, SEC, UNITS) VALUES (%s, %s, %s, %s, %s, %s)", (coursedata[0], coursedata[1], coursedata[2], coursedata[3], coursedata[4], coursedata[5]))
            next(line)
            next(line)
            meetingdata = next(line)
            instructor = meetingdata[0]
            while len(meetingdata) > 1:
                cursor.execute("INSERT INTO MEETING (INSTRUCTOR, TYPE, DAYS, TIME, BUILD, ROOM) VALUES (%s, %s, %s, %s, %s, %s)", (instructor, meetingdata[1], meetingdata[2], meetingdata[3], meetingdata[4], meetingdata[5]))
                meetingdata = next(line)
            next(line)
            try:
                studentdata = next(line)
                while len(studentdata) > 1:
                    if studentdata[8] == "A+":
                       gradepoint = 4.0
                    elif studentdata[8] == "A":
                       gradepoint = 4.0
                    elif studentdata[8] == "A-":
                       gradepoint = 3.7
                    elif studentdata[8] == "B+":
                       gradepoint = 3.3
                    elif studentdata[8] == "B":
                       gradepoint = 3.0
                    elif studentdata[8] == "B-":
                       gradepoint = 2.7
                    elif studentdata[8] == "C+":
                       gradepoint = 2.3
                    elif studentdata[8] == "C":
                       gradepoint = 2.0
                    elif studentdata[8] == "C-":
                       gradepoint = 1.7
                    elif studentdata[8] == "D+":
                       gradepoint = 1.3
                    elif studentdata[8] == "D":
                       gradepoint = 1.0
                    elif studentdata[8] == "D-":
                       gradepoint = 0.7
                    else:
                       gradepoint = 0
                    cursor.execute("INSERT INTO STUDENT(CID, SUBJ, SEAT, SID, SURNAME, PREFNAME, LEVEL, UNITS, CLASS, MAJOR, GRADE, STATUS, EMAIL, GP) VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)", (coursedata[0], coursedata[2], studentdata[0], studentdata[1], studentdata[2], studentdata[3], studentdata[4], studentdata[5],studentdata[6],studentdata[7],studentdata[8],studentdata[9],studentdata[10], gradepoint))
                    studentdata = next(line)
            except StopIteration:
                print("finished loading file: " + file)
    ifile.close()

conn.commit()
conn.close()
print("end of load")
