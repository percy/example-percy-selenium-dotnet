NPM=node_modules/.bin

.PHONY: install clean test test-advanced test-advanced-ci

$(NPM):
	npm install --no-save @percy/cli@^1.31.13

dotnet-restore:
	dotnet restore

install: $(NPM) dotnet-restore

clean:
	rm -rf bin obj node_modules advanced-requests.json

# Local run against a real PERCY_TOKEN. Spawns the basic ../Server project at
# localhost:8000, runs the advanced tests against it, kills the server.
test test-advanced: install
	{ dotnet run --no-restore --project ../Server & }; \
	pid=$$!; \
	$(NPM)/percy exec -- dotnet test --no-restore; \
	r=$$?; \
	kill $$pid 2>/dev/null; \
	exit $$r

# CI run in --testing mode + capture requests file.
test-advanced-ci: install
	{ dotnet run --no-restore --project ../Server & }; \
	pid=$$!; \
	PERCY_TOKEN=fake_token $(NPM)/percy exec --testing -- bash -c '\
		dotnet test --no-restore; \
		ec=$$?; \
		curl -fsS http://localhost:5338/test/requests > advanced-requests.json || true; \
		exit $$ec'; \
	r=$$?; \
	kill $$pid 2>/dev/null; \
	exit $$r
