using System;
using System.Collections.Generic;
using MEC;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;

namespace HintReminder
{
    public class HintReminderPlugin : Plugin<HintReminderConfig>
    {
        public override string Author => "zazarick";
        public override string Name => "HintReminder";
        public override string Prefix => "hintreminder";
        public override Version Version => new Version(1, 0, 0);

        private CoroutineHandle reminderCoroutine;

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            Timing.KillCoroutines(reminderCoroutine);
            base.OnDisabled();
        }

        private void OnRoundStarted()
        {
            if (reminderCoroutine.IsRunning)
                Timing.KillCoroutines(reminderCoroutine);

            reminderCoroutine = Timing.RunCoroutine(ReminderCoroutine());
        }

        private IEnumerator<float> ReminderCoroutine()
        {
            var allMessages = new List<string>(Config.StandardMessages);
            allMessages.AddRange(Config.HintMessages);
            for (int i = 0; i < allMessages.Count; i++)
            {
                allMessages[i] = new string('\n', Config.NewlineCount) + allMessages[i];
            }

            int index = 0;
            while (true)
            {
                string msg = allMessages[index % allMessages.Count];
                foreach (var ply in Player.List)
                {
                    ply.ShowHint(msg, Config.HintDuration);
                }
                yield return Timing.WaitForSeconds(Config.MessageInterval);

                index++;
            }
        }
    }
}
