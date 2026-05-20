# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is the official SiliconFlow (硅基流动) translation plugin for [STranslate](https://github.com/STranslate/STranslate). It connects to SiliconFlow's OpenAI-compatible API (`https://api.siliconflow.cn/v1/chat/completions`) to provide LLM-based translation, text polishing, and summarization via SSE streaming.

## Build Commands

```powershell
# Build (Release produces .spkg plugin package in .artifacts/plugins/)
dotnet build .\STranslate.Plugin.Translate.SiliconFlow\STranslate.Plugin.Translate.SiliconFlow.csproj --configuration Release

# Build (Debug outputs to ..\..\..\.artifacts\Debug\Plugins\ for live testing with STranslate)
dotnet build .\STranslate.Plugin.Translate.SiliconFlow\STranslate.Plugin.Translate.SiliconFlow.csproj --configuration Debug
```

Target framework is `net10.0-windows` with WPF enabled. No test project exists.

## Architecture

- **Main.cs** — Plugin entry point. Extends `LlmTranslatePluginBase` (from the `STranslate.Plugin` NuGet package). Implements `Init`, `TranslateAsync`, `GetSettingUI`, and language mapping. Streaming responses are parsed from SSE format (`data: {json}` lines terminated by `data: [DONE]`), extracting `choices[0].delta.content`.
- **Settings.cs** — Persisted configuration POCO (URL, API key, model, model list, think mode, prompts). Serialized/deserialized via `IPluginContext.LoadSettingStorage<T>` / `SaveSettingStorage<T>`.
- **ViewModel/SettingsViewModel.cs** — MVVM ViewModel using CommunityToolkit.Mvvm. Auto-saves on any property change via `IPluginContext.SaveSettingStorage`.
- **View/SettingsView.xaml** — WPF UserControl for the plugin settings UI using iNKORE UI components.
- **Languages/** — Localization files. Each language has both a `.json` (plugin metadata) and `.xaml` (resource dictionary for UI strings).
- **plugin.json** — Plugin manifest (ID, name, version, entry DLL).

## Key Patterns

- The plugin SDK types (`LlmTranslatePluginBase`, `IPluginContext`, `Prompt`, `TranslateRequest`, etc.) come from the `STranslate.Plugin` package. There are no local interfaces to implement beyond what the base class requires.
- Prompt template variables: `$source` (source language name), `$target` (target language name), `$content` (text to translate).
- Settings persistence is fully managed by the host app — call `Context.SaveSettingStorage<Settings>()` after mutations.
- The `Think` property maps to SiliconFlow's `enable_thinking` parameter for deep reasoning models (e.g., DeepSeek-R1). The response field `choices[0].delta.reasoning_content` carries reasoning output.

## Localization

Supported languages: en, ja, ko, zh-cn, zh-tw. To add a new language, create both `Languages/{locale}.json` and `Languages/{locale}.xaml` with the same keys as existing files.
