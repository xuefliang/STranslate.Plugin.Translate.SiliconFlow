# STranslate 硅基流动翻译插件

基于 [硅基流动 (SiliconFlow)](https://siliconflow.cn/) 云端大模型的 STranslate 翻译插件。

## 📦 安装

1. 下载最新的 `.spkg` 文件（在 [Releases](https://github.com/STranslate/STranslate.Plugin.Translate.SiliconFlow/releases) 页面）
2. 在 STranslate 中进入 **设置** → **插件** → **安装插件**
3. 选择下载的 `.spkg` 文件并重启 STranslate

## 前置条件

需要在 [硅基流动](https://cloud.siliconflow.cn/) 注册账号并获取 API Key：

1. 访问 [cloud.siliconflow.cn](https://cloud.siliconflow.cn/)
2. 注册并登录
3. 进入 **API密钥** 页面创建密钥

### 支持模型

默认预置以下模型，也可在设置中自由添加：
- `Qwen/Qwen2.5-72B-Instruct`
- `Pro/deepseek-ai/DeepSeek-R1`
- `deepseek-ai/DeepSeek-V3`

完整模型列表请参考 [硅基流动模型广场](https://cloud.siliconflow.cn/models)。

### 提示词模板

支持自定义提示词，内置：
- **翻译** - 专业翻译引擎
- **润色** - 文本润色优化
- **总结** - 文本摘要生成

提示词变量：`$source`（源语言）、`$target`（目标语言）、`$content`（待翻译文本）

## 📄 许可证

[MIT](LICENSE)
