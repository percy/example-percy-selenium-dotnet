# Advanced Percy + Selenium-.NET example

This directory exercises the full applicable Percy SDK feature surface for `PercyIO.Selenium`. See the basic example at the repo root for the minimum integration.

## What this example covers

An xUnit suite (`AdvancedTest.cs`) where each `[Fact]` exercises one row of the [Percy SDK Advanced Feature Matrix](../../../docs/advanced-example-feature-matrix.md). Most tests use the `Dictionary<string, object>` options overload; one demonstrates the anonymous-object overload (`new { enableJavaScript = true }`). Global SDK config — readiness preset, default widths, percyCSS, discovery — lives in `.percy.yml`.

The advanced tests reuse the basic example's ASP.NET `../Server` project at `localhost:8000`. The Makefile starts and stops it.

Note: `scope`, `domTransformation`, `discovery` are marked `N/A` — not exposed in `PercyIO.Selenium` 2.1.4 DOM-snapshot surface.

## Run locally

```bash
cd advanced
make install                       # restores nuget + installs @percy/cli
export PERCY_TOKEN="<your token>"  # do NOT commit this
make test
```

To run without a real token (CI assertion mode):

```bash
make test-advanced-ci   # uses --testing + PERCY_TOKEN=fake_token + captures /test/requests
```

The CI variant asserts every matrix row appears in the captured POST bodies at the local `/test/requests` endpoint. No real Percy build is created.

## Coverage matrix

States: `Covered` / `N/A — <reason>` / `Planned` / `Deprecated`. Source of truth is [`matrix.yml`](./matrix.yml).

| Feature | State | Test |
|---|---|---|
| widths (Dictionary) | Covered | `ExercisesWidths` |
| minHeight (Dictionary) | Covered | `ExercisesMinHeight` |
| enableJavaScript (Dictionary) | Covered | `ExercisesEnableJavaScript` |
| responsiveSnapshotCapture (Dictionary) | Covered | `ExercisesResponsiveSnapshotCapture` |
| readiness preset (Dictionary) | Covered | `ExercisesReadiness` |
| sync (Dictionary) | Covered | `ExercisesSync` |
| labels (Dictionary) | Covered | `ExercisesLabels` |
| testCase (Dictionary) | Covered | `ExercisesTestCase` |
| devicePixelRatio (Dictionary) | Covered | `ExercisesDevicePixelRatio` |
| browsers (Dictionary) | Covered | `ExercisesBrowsers` |
| regions (Dictionary) | Covered | `ExercisesRegions` |
| Dictionary<string,object> overload | Covered | 11 `Exercises*` tests use this overload |
| Anonymous-object overload | Covered | `ExercisesAnonymousObjectOverload` |
| percyCSS | Covered | global via `.percy.yml` |
| `.percy.yml` global config | Covered | `.percy.yml` consumed at build start |
| environment info reporting | Covered | automatic via `PercyIO.Selenium` client info |
| PERCY_SERVER_ADDRESS via env | Covered | CI advanced job picks up `PERCY_SERVER_ADDRESS` |
| `Percy.CreateRegion` static helper | Planned | — |
| `scope` | N/A | Not exposed in SDK 2.1.4 DOM-snapshot surface |
| `domTransformation` | N/A | Not exposed in SDK 2.1.4 DOM-snapshot surface |
| `discovery` per-snapshot | N/A | discovery is per-build only |
