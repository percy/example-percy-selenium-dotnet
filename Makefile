NPM=node_modules/.bin
NPMDEPS=$(package-lock.json)
NETDEPS=$(packages.lock.json)

.PHONY: npm dotnet install clean serve test

npm: $(NPMDEPS)
	npm install

dotnet: $(NETDEPS)
	dotnet restore

install: npm dotnet

clean:
	git clean -Xdf

serve: install
	dotnet run --no-restore --project Server

test: install
	{ dotnet run --no-restore --project Server & }; \
	pid=$$!; \
	$(NPM)/percy exec -- dotnet test --no-restore; \
	r=$$?; \
	kill $$pid; \
	exit $$r
