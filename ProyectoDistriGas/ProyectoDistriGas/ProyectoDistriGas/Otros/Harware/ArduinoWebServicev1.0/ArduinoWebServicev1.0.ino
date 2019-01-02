
#include <WiFi.h>
#include <aREST.h>

aREST rest = aREST(); // instanciamos el objeto
const char* ssid = "INTERNET CNT";
const char* password = "12345678";
WiFiServer server(80);// creamos una intancia del servidor con el puerto 80
int porcentaje=9; // variable del sensor leido
// Declare functions to be exposed to the API
int ledControl(String command);
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
  }
  // mensajes por serial
  Serial.println("");
  Serial.println("WiFi connected");

  server.begin();// iniciamos el servidor

  Serial.println("Server started");

  Serial.println(WiFi.localIP());// imprimimos la direccion ip asignada al servidor
}
void loop() {
  // Handle REST calls
  WiFiClient client = server.available();
  if (!client) {
    return;
  }
  while(!client.available()){
    delay(1);
  }
  rest.handle(client);
}
int ledControl(String command) {

  // Get state from command
  int state = command.toInt();

  digitalWrite(6,state);
  return 1;
}
