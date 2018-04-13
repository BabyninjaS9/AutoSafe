/**
 * This file is part of AutoSafe firmware.
 *
 * Copyright (c) 2018, AutoSafe, Inc
 */

#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>

#define AP_SSID "AutoSafe"
#define AP_PASS "12345678"

#define MAX_CLIENTS 20

WiFiServer server(23);
WiFiClient clients[MAX_CLIENTS];

enum operating_mode {
    OPERATING_MODE_SERVER,
    OPERATING_MODE_CLIENT
};

static enum operating_mode mode;

void setup(void)
{
    Serial.begin(9600);
    while (!Serial);

    WiFi.mode(WIFI_STA);
    WiFi.begin(AP_SSID, AP_PASS);

    if (WiFi.status() != WL_CONNECTED) {
        WiFi.mode(WIFI_AP);
        WiFi.softAP(AP_SSID, AP_PASS);

        server.begin();

        Serial.print("IP address: ");
        Serial.println(WiFi.softAPIP());

        mode = OPERATING_MODE_SERVER;
    } else {
        mode = OPERATING_MODE_CLIENT;
    }
}

static void handleIncomingClient(WiFiClient client)
{
    for (int i = 0; i < MAX_CLIENTS; i++) {
        if (!clients[i] || !clients[i].connected()) {
            if (clients[i]) {
                clients[i].stop();
            }

            clients[i] = client;
            break;
        }

        if (i == MAX_CLIENTS - 1) {
            client.stop();
        }
    }
}

static void handleIncomingData(void)
{
    for (int i = 0; i < MAX_CLIENTS; i++) {
        if (clients[i] && clients[i].connected()) {
            while (clients[i].available()) {
                Serial.write(clients[i].read());
            }
        }
    }
}

static void handleUART(void)
{
    if (Serial.available()) {
        size_t len = Serial.available();
        uint8_t buf[len];

        Serial.readBytes(buf, len);

        for (int i = 0; i < MAX_CLIENTS; i++) {
            if (clients[i] && clients[i].connected()) {
                clients[i].write(buf, len);
                delay(1);
            }
        }
    }
}

static void serverMode(void)
{
    if (server.hasClient()) {
        Serial.println("New client!");
        handleIncomingClient(server.available());
    }

    handleIncomingData();
    handleUART();
}

static void clientMode(void)
{
    handleUART();
}

void loop(void)
{
    switch (mode) {
    case OPERATING_MODE_SERVER:
        serverMode();
        break;

    case OPERATING_MODE_CLIENT:
        clientMode();
        break;

    default:
        break;
    }
}
