// PER-8195 Phase 1 — selenium-dotnet advanced example.
// Each [Fact] exercises one row of the Advanced Feature Matrix. See
// ../matrix.yml for the canonical mapping of test name -> matrix row.

using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using PercyIO.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace Server.Test.Advanced;

public class AdvancedFixture : IDisposable
{
    public readonly FirefoxDriver Driver;

    public AdvancedFixture()
    {
        new DriverManager().SetUpDriver(new FirefoxConfig());
        var options = new FirefoxOptions { LogLevel = FirefoxDriverLogLevel.Fatal };
        options.AddArgument("--headless");
        Driver = new FirefoxDriver(options);
    }

    public void Dispose() => Driver.Quit();
}

public class AdvancedTests : IClassFixture<AdvancedFixture>
{
    private readonly FirefoxDriver _driver;

    public AdvancedTests(AdvancedFixture fixture)
    {
        _driver = fixture.Driver;
        _driver.Navigate().GoToUrl("http://localhost:8000");
        _driver.FindElement(By.ClassName("new-todo")).SendKeys("Walk the dog" + Keys.Enter);
    }

    [Fact]
    public void ExercisesWidths()
    {
        Percy.Snapshot(_driver, "AdvancedTests > ExercisesWidths",
            new Dictionary<string, object> { { "widths", new[] { 375, 768, 1280, 1920 } } });
    }

    [Fact]
    public void ExercisesMinHeight()
    {
        Percy.Snapshot(_driver, "AdvancedTests > ExercisesMinHeight",
            new Dictionary<string, object> { { "minHeight", 2000 } });
    }

    [Fact]
    public void ExercisesEnableJavaScript()
    {
        Percy.Snapshot(_driver, "AdvancedTests > ExercisesEnableJavaScript",
            new Dictionary<string, object> { { "enableJavaScript", true } });
    }

    [Fact]
    public void ExercisesResponsiveSnapshotCapture()
    {
        Percy.Snapshot(_driver, "AdvancedTests > ExercisesResponsiveSnapshotCapture",
            new Dictionary<string, object>
            {
                { "responsiveSnapshotCapture", true },
                { "widths", new[] { 375, 1280 } },
            });
    }

    [Fact]
    public void ExercisesReadiness()
    {
        Percy.Snapshot(_driver, "AdvancedTests > ExercisesReadiness",
            new Dictionary<string, object>
            {
                { "readiness", new Dictionary<string, object>
                    {
                        { "preset", "strict" },
                        { "timeoutMs", 5000 },
                    } },
            });
    }

    [Fact]
    public void ExercisesSync()
    {
        Percy.Snapshot(_driver, "AdvancedTests > ExercisesSync",
            new Dictionary<string, object> { { "sync", false } });
    }

    [Fact]
    public void ExercisesLabels()
    {
        Percy.Snapshot(_driver, "AdvancedTests > ExercisesLabels",
            new Dictionary<string, object> { { "labels", "smoke,sdk-dotnet" } });
    }

    [Fact]
    public void ExercisesTestCase()
    {
        Percy.Snapshot(_driver, "AdvancedTests > ExercisesTestCase",
            new Dictionary<string, object> { { "testCase", "todomvc-advanced-suite" } });
    }

    [Fact]
    public void ExercisesDevicePixelRatio()
    {
        Percy.Snapshot(_driver, "AdvancedTests > ExercisesDevicePixelRatio",
            new Dictionary<string, object> { { "devicePixelRatio", 2 } });
    }

    [Fact]
    public void ExercisesBrowsers()
    {
        Percy.Snapshot(_driver, "AdvancedTests > ExercisesBrowsers",
            new Dictionary<string, object>
            {
                { "browsers", new[] { "chrome", "firefox" } },
            });
    }

    [Fact]
    public void ExercisesRegions()
    {
        var bbox = new Dictionary<string, object>
        {
            { "x", 0 }, { "y", 0 }, { "width", 200 }, { "height", 100 },
        };
        var region = new Dictionary<string, object>
        {
            { "algorithm", "ignore" },
            { "elementSelector", new Dictionary<string, object> { { "boundingBox", bbox } } },
        };
        Percy.Snapshot(_driver, "AdvancedTests > ExercisesRegions",
            new Dictionary<string, object> { { "regions", new[] { region } } });
    }

    [Fact]
    public void ExercisesAnonymousObjectOverload()
    {
        // PercyIO.Selenium also accepts an anonymous object as options.
        Percy.Snapshot(_driver, "AdvancedTests > ExercisesAnonymousObjectOverload",
            new { enableJavaScript = true, minHeight = 1024 });
    }
}
