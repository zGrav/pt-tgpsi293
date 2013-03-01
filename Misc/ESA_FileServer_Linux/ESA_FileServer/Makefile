
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -unsafe -warn:4 -optimize+ -debug "-define:DEBUG;" "-main:ESA_FileServer.MainClass"
ASSEMBLY = bin/Debug/ESA_FileServer.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

ESA_FILESERVER_EXE_MDB_SOURCE=bin/Debug/ESA_FileServer.exe.mdb
ESA_FILESERVER_EXE_MDB=$(BUILD_DIR)/ESA_FileServer.exe.mdb

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -unsafe -warn:4 -optimize+ "-main:ESA_FileServer.MainClass"
ASSEMBLY = bin/Release/ESA_FileServer.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

ESA_FILESERVER_EXE_MDB=

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(ESA_FILESERVER_EXE_MDB)  

BINARIES = \
	$(ESA_FILESERVERLAUNCH)  


RESGEN=resgen2

ESA_FILESERVERLAUNCH = $(BUILD_DIR)/esa_fileserverlaunch

FILES = \
	Main.cs \
	AssemblyInfo.cs \
	TextHandling.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	esa_fileserverlaunch.in 

REFERENCES =  \
	System \
	System.Core \
	System.Data

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-wrapper,ESA_FILESERVERLAUNCH,esa_fileserverlaunch,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ESA_FILESERVER_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(bindir)'
	$(call cp,$(ESA_FILESERVERLAUNCH),$(DESTDIR)$(bindir))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ESA_FILESERVER_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ESA_FILESERVERLAUNCH),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
