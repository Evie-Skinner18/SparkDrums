
# Project variables
# ?= means if this var doesn't have a value, set it to SparkDrums as default
PROJECT_NAME ?= SparkDrums
ORG_NAME ?= SparkDrums
REPO_NAME ?= SparkDrums


.PHONY: migration db api client test

migration:
	cd ./backend/SparkDrums.Data && dotnet ef --startup-project ../SparkDrums.Api migrations add $(migrationName) && cd ../../
db:
	cd ./backend/SparkDrums.Data && dotnet ef --startup-project ../SparkDrums.Api database update && cd ../../
api:
	cd ./backend/SparkDrums.Api && dotnet run && cd ../../


client: cd ./frontend && npm run serve && cd ../


test: cd ./backend && dotnet test && cd ../