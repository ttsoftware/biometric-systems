include ../../../Common/Build/config.mk

### target ###

TARGET_NAME   = ReadVideoFromDevice

### Objects, sources ###

# C source files

CSRCS = \
	ReadVideoFromDevice.c

ifeq ($(N_MAC_OSX_FRAMEWORKS),yes)
  LDLIBS ?= -framework NMedia -framework NCore -framework NLicensing
else
  LDLIBS ?= -lNMedia -lNCore -lNLicensing
endif

include ../../../Common/Build/rules.mk

