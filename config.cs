using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace HintReminder
{
    public class HintReminderConfig : IConfig
    {
        [Description("Включить или выключить плагин")]
        public bool IsEnabled { get; set; } = true;

        [Description("Промежуток между сообщениями (в секундах)")]
        public float MessageInterval { get; set; } = 8f;

        [Description("Длительность показа сообщения (в секундах)")]
        public float HintDuration { get; set; } = 6f;

        [Description("Сколько \\n добавить в начало каждого сообщения, чтобы текст был максимально внизу")]
        public int NewlineCount { get; set; } = 18;

        [Description("Стандартные приветственные/информационные сообщения")]
        public List<string> StandardMessages { get; set; } = new List<string>
        {
            "<color=yellow>Добро пожаловать на сервер <color=lime>test</color>!</color>",
            "<color=orange>Помните: соблюдайте правила сервера.</color>",
        };

        [Description("Памятки (советы для игроков, выводятся по очереди)")]
        public List<string> HintMessages { get; set; } = new List<string>
        {
            "<color=red>Не забывайте использовать рацию для общения!</color>",
            "<color=cyan>Открывайте двери только своим!</color>",
            "<color=lime>Следите за уровнем здоровья!</color>",
            "<color=magenta>Соблюдайте дисциплину и уважайте других игроков.</color>",
        };

        [Description("Включить режим отладки")]
        public bool Debug { get; set; } = false;
    }
}
