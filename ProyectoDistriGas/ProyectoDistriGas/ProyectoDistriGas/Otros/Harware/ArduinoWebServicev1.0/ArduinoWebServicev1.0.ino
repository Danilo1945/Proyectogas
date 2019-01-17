
// Arduino pin 5V -> HX711 VCC
// Arduino pin GND -> HX711 GND 

#include <WiFi.h>
#include <aREST.h>
#include "HX711.h"
aREST rest = aREST(); // instanciamos el objeto
const char* ssid = "LUIS";
const char* password = "1234567890";

//para hx711
HX711 scale(26, 27);
float calibration_factor = 8000; // this calibration factor is adjusted according to my load cell
float units;
float ounces;

WiFiServer server(80);// creamos una intancia del servidor con el puerto 80
int porcentaje=89; // variable del sensor leido
int ledControl(String command);// Declare functions to be exposed to the API


void setup()
 {
 
  // Start Serial
  Serial.begin(115200);// iniciamos el puerto serial para que este en el puerto 115200

  rest.variable("porcentaje",&porcentaje);// contruimos el json
  rest.set_id("1");
  rest.set_name("esp32");
  
  // conectamos al wifi
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
    randomSeed(10);
/// para xh711
    scale.set_scale();
  scale.tare();  //Reset the scale to 0

  long zero_factor = scale.read_average(); //Get a baseline reading
  }
 

  Serial.println("WiFi connected"); // mensajes por serial
  server.begin();// iniciamos el servidor
  Serial.println("Server started");
  Serial.println(WiFi.localIP());// imprimimos la direccion ip asignada al servidor
}

int GetPeso(){
    scale.set_scale(calibration_factor); //Adjust to this calibration factor

 // Serial.print("Reading: ");
  units = scale.get_units(), 10;
  if (units < 0)
  {
    units = 0.00;
  }
  ounces = units * 0.035274;
int respuesta=0;

respuesta = (int) units; // ahora i es 3

  
return respuesta;
  }

int GetCantidadGas(){
  int respuesta=33;
  ///aqui programacion 





  
  return respuesta;
  }


  

void loop() {
  porcentaje=GetCantidadGas();
  WiFiClient client = server.available(); // comprueba si el sendor esta disponible
  if (!client) {
    return;
  }
  while(!client.available()){  // comprueba si el cliente esta disponible
    delay(1);
  }
  rest.handle(client);
}

int ledControl(String command) {
  int state = command.toInt();// Get state from command
  digitalWrite(6,state);
  return 1;
}
