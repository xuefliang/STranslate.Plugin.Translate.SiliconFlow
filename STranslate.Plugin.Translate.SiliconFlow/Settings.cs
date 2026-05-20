namespace STranslate.Plugin.Translate.SiliconFlow;

public class Settings
{
    public string ApiKey { get; set; } = string.Empty;
    public string Url { get; set; } = "https://api.siliconflow.cn";
    public string Model { get; set; } = "Qwen/Qwen2.5-72B-Instruct";
    public List<string> Models { get; set; } =
    [
        "Qwen/Qwen2.5-72B-Instruct",
        "Pro/deepseek-ai/DeepSeek-R1",
        "deepseek-ai/DeepSeek-V3",
    ];
    public bool Stream { get; set; } = true;
    public bool Think { get; set; } = false;

    public List<Prompt> Prompts { get; set; } =
    [
        new("翻译",
        [
            new PromptItem("system", "You are a professional, authentic translation engine. You only return the translated text, without any explanations."),
            new PromptItem("user", "Please translate  into $target (avoid explaining the original text):\r\n\r\n$content"),
        ], true),
        new("润色",
        [
            new PromptItem("system", "You are a professional, authentic text polishing engine. You only return the polished text, without any explanations."),
            new PromptItem("user", "Please polish the following text in $source (avoid explaining the original text):\r\n\r\n$content"),
        ]),
        new("总结",
        [
            new PromptItem("system", "You are a professional, authentic text summarization engine. You only return the summarized text, without any explanations."),
            new PromptItem("user", "Please summarize the following text in $source (avoid explaining the original text):\r\n\r\n$content"),
        ]),
    ];
}
