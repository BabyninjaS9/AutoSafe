/**
 * AutoSafe Firmware
 *
 * Copyright (c) 2018, AutoSafe, Inc.
 */

#include <stdio.h>

#include "protocol.h"

int main(void)
{
    struct packet packet = { 0 };
    uint8_t data[] = { 0x0E, 0xE0, 0x9, 0b00100010, 0x1, 0x2, 0x3, 0x42, 0xE5 };
    size_t size = 9;

    if (packet_deserialize(&packet, data, size) != 0) {
        printf("Something went wrong while deserializing a packet.\n");
        return 1;
    }

    printf("packet {\n"
           "\tmagic = 0x%X\n"
           "\tlength = 0x%X\n"
           "\tcategory = 0x%X\n"
           "\tcommand = 0x%X\n"
           "\tchecksum = 0x%X\n"
           "}\n",
           packet.magic,
           packet.length,
           packet.category,
           packet.command,
           packet.checksum);


    return 0;
}
