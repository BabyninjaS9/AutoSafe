/**
 * AutoSafe Firmware
 *
 * Copyright (c) 2018, AutoSafe, Inc.
 */

#ifndef __PROTOCOL_H__
#define __PROTOCOL_H__

#include <stdint.h>

#ifdef __cplusplus
extern "C" {
#endif

/**
 * The magic number which indicates the start of a packet.
 */
#define PACKET_MAGIC 0x0EE0

/**
 * The number of fixed bytes in a packet. This can be used to calculate the size
 * of the payload.
 */
#define PACKET_FIXED 6

/**
 * Represents a single packet.
 */
struct packet
{
    uint16_t magic;
    uint16_t length:8;
    uint16_t category:3;
    uint16_t command:5;

    uint8_t* payload;

    uint16_t checksum;
};

/**
 * Serializes the provided packet into a byte stream.
 *
 * The data must have memory allocated before calling this function.
 *
 * @param packet Packet to convert into a byte stream.
 * @param data   Destination of the byte stream.
 * @Param size   Destination of the byte stream size.
 *
 * @return 0 on success, otherwise -1.
 */
int packet_serialize(struct packet* packet, uint8_t* data, size_t* size);

/**
 * Deserializes the given bytes into a packet data structure.
 *
 * @param packet Destination of the packet.
 * @param data   Byte stream to convert into a packet.
 * @param size   Size of the byte stream.
 *
 * @return 0 on success, otherwise -1.
 */
int packet_deserialize(struct packet* packet, const uint8_t* data, const size_t size);

#ifdef __cplusplus
}
#endif

#endif
