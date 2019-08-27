CUR=${PWD}

.PHONY: build
build:
	docker run -v "${CUR}:/work" uber/prototool:latest prototool generate