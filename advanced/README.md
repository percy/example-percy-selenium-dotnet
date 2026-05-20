# Advanced Percy + Selenium-.NET example — STUB

**Status:** Phase 1 stub. `matrix.yml` is populated based on `PercyIO.Selenium` research. Test code in `Server.Test/AdvancedTest.cs` is **not yet written**.

See the basic example at the repo root. See [`matrix.yml`](./matrix.yml) for the planned matrix-row coverage.

## What this example will cover

Each test will exercise one row of the matrix using BOTH option-passing shapes: `Dictionary<string, object>` and anonymous-object overload (`new { enableJavaScript = true }`). Includes `Percy.CreateRegion` static helper for regions.

Note: `scope`, `dom_transformation`, `discovery` are marked `N/A` — not exposed in `PercyIO.Selenium` 2.1.4 DOM-snapshot surface (some exist as Automate-only options on `Percy.Screenshot`).

## Run locally (once tests are written)

```bash
cd advanced
# CLI managed separately via npm
npm install -g @percy/cli
export PERCY_TOKEN="<your project token>"      # do NOT commit
npx percy exec -- dotnet test
```

## Coverage matrix

Source of truth: [`matrix.yml`](./matrix.yml).

> Phase 1 stub: most rows are currently `Planned`. Basic example has three bare `Percy.Snapshot` calls. `ReadinessTest.cs` already exercises readiness preset variants.
