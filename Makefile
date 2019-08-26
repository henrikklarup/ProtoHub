.PHONY: build
build:
	docker run -v "$(pwd):/work" uber/prototool:latest prototool generate