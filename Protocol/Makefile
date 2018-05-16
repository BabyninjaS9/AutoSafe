# options
CC=gcc
CFLAGS=-g -Wall -Werror -Wno-missing-field-initializers
TARGET=autosafe

# globs
SRCS := $(wildcard src/*.c)
HDRS := $(wildcard src/*.h)
OBJS := $(patsubst src/%.c,bin/%.o,$(SRCS))

# link it all together
$(TARGET): $(OBJS) $(HDRS) Makefile
	@mkdir -p bin
	$(CC) $(CFLAGS) $(OBJS) -o $(TARGET)

# compile an object based on source and headers
bin/%.o: src/%.c $(HDRS) Makefile
	@mkdir -p bin
	$(CC) $(CFLAGS) -c $< -o $@

# tidy up
clean:
	rm -f $(TARGET) $(OBJS)
