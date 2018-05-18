/**
 * AutoSafe Firmware
 *
 * Copyright (c) 2018, AutoSafe, Inc.
 */

#include <assert.h>
#include <stdio.h>
#include <stdlib.h>

#include "protocol.h"

enum parse_state {
    PS_MAGIC,
    PS_LENGTH,
    PS_COMMAND,
    PS_PAYLOAD,
    PS_CHECKSUM
};

int packet_serialize(struct packet* packet, uint8_t* data, size_t* size)
{
    if (packet == NULL) {
        return -1;
    }

    data = malloc(packet->length);

    if (data == NULL) {
        return -1;
    }

    return 0;
}

int packet_deserialize(struct packet* packet, const uint8_t* data, const size_t size)
{
    if (packet == NULL || data == NULL) {
        return -1;
    }

    enum parse_state state = PS_MAGIC;

    for (size_t i = 0; i < size; i++) {
        switch (state) {
        case PS_MAGIC:
            packet->magic = data[i] << 8 | data[i + 1];
            i++;
            state = PS_LENGTH;
            break;

        case PS_LENGTH:
            packet->length = data[i];
            packet->payload = malloc(packet->length - 5);

            if (packet->payload == NULL) {
                return -1;
            }

            state = PS_COMMAND;
            break;

        case PS_COMMAND:
            packet->category = data[i] >> 5;
            packet->command = data[i] & 0b00011111;
            state = PS_PAYLOAD;
            break;

        case PS_PAYLOAD:
            packet->payload[i - 3] = data[i];

            if (i - 3 == packet->length - PACKET_FIXED) {
                state = PS_CHECKSUM;
            }
            break;

        case PS_CHECKSUM:
            packet->checksum = data[i] << 8 | data[i + 1];
            i++;
            break;

        default:
            assert(0);
        }
    }

    return 0;
}
