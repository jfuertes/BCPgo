import json
import argparse
import datetime
import imutils
import math
import cv2
import numpy as np
import urllib2
import requests

width = 800

textIn = 0
textOut = 0


countFrameCola = 0
genteCola = 0
def testIntersectionIn(x, y):
    global countFrameCola
    if((x>200) and (y>120) and (x<350)):
        countFrameCola += 1
        return True
    return False

count =0



countFrameCajero = 0
def testIntersectionOut(x, y):
    global countFrameCajero
    if((x>420) and (y>120) and (x<540)):
        countFrameCajero += 1
        return True
    return False


camera = cv2.VideoCapture("test2.mp4")

firstFrame = None

while True:

    (grabbed, frame) = camera.read()
    text = "Unoccupied"
    count += 1

    if not grabbed:
        break

    # convierte frames a griz y azul
    frame = imutils.resize(frame, width=width)
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    gray = cv2.GaussianBlur(gray, (21, 21), 0)

    # inicializa frames
    if firstFrame is None:
        firstFrame = gray
        continue

    # comprueba diferencias entre el actual frame y el anterior
    frameDelta = cv2.absdiff(firstFrame, gray)
    thresh = cv2.threshold(frameDelta, 25, 255, cv2.THRESH_BINARY)[1]
    # 
    thresh = cv2.dilate(thresh, None, iterations=2)
    _, cnts, _ = cv2.findContours(thresh.copy(), cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
    for c in cnts:
        if cv2.contourArea(c) < 12000:
            continue
        (x, y, w, h) = cv2.boundingRect(c)
        cv2.rectangle(frame, (x, y), (x + w, y + h), (0, 255, 0), 2)

        cv2.line(frame, (width / 2 +140, 0), (width/2 +140, 450), (250, 0, 1), 2)
        cv2.line(frame, (width / 2 +20 , 0), (width/2 +20, 450), (0, 0, 255), 2)


        rectagleCenterPont = ((x + x + w) /2, (y + y + h) /2)
        cv2.circle(frame, rectagleCenterPont, 1, (0, 0, 255), 5)

        if(testIntersectionIn((x + x + w) / 2, (y + y + h) / 2)):
            textIn += 1

        if(testIntersectionOut((x + x + w) / 2, (y + y + h) / 2)):
            textOut += 1


    if cv2.waitKey(1) & 0xFF == ord('q'):
        break

    cv2.putText(frame, "Cola: {}".format(str(textIn)), (10, 50),
                cv2.FONT_HERSHEY_SIMPLEX, 0.5, (0, 0, 255), 2)
    cv2.putText(frame, "Cajero: {}".format(str(textOut)), (10, 70),
                cv2.FONT_HERSHEY_SIMPLEX, 0.5, (0, 0, 255), 2)
    cv2.putText(frame, datetime.datetime.now().strftime("%A %d %B %Y %I:%M:%S%p"),
                (10, frame.shape[0] - 10), cv2.FONT_HERSHEY_SIMPLEX, 0.35, (0, 0, 255), 1)
    cv2.imshow("Security Feed", frame)

camera.release()
cv2.destroyAllWindows()

timEspera = 0
cajeroId = 200

if(countFrameCola > 100):
    genteCola = countFrameCola / 100

timEspera = countFrameCajero/30 *  genteCola

cajero = {}
cajero["id"] = str(cajeroId)
cajero["tiempo_estimado"]  = str(timEspera)

cajero = {"id": str(cajeroId),  "tiempo_estimado": str(timEspera)}



with open('file.json', 'w') as file:
    json.dump(cajero, file)

req = urllib2.Request('http://18.191.14.35/alarmas/sistema/api/tiempo_estimado.php')
req.add_header('Content-Type', 'application/json')



try:
    response = urllib2.urlopen(req, json.dumps(cajero))
    contents = response.read()
    if (response.getcode() == 200):
        print "Enviado correctamente al servidor:"
        print cajero
        print "Status: 200 OK"
except urllib2.HTTPError, error:
    print "col"
    contents = error.read()
print "Finish"


