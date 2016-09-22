namespace System.Threading
{
    public static class TimerExtensions
    {
        /// <summary>
        /// 變更計時器每日執行方法的時間。
        /// </summary>
        /// <param name="timer"></param>
        /// <param name="dueHours">小時 (0 到 23)。</param>
        /// <param name="dueMinutes">分鐘 (0 到 59)。</param>
        /// <param name="dueSeconds">秒數 (0 到 59)。</param>
        /// <param name="worldTimeZone">開始時間的目標時區。</param>
        public static void ChangeToDaily(this Timer timer,
                                                short dueHours = 0,
                                                short dueMinutes = 0,
                                                short dueSeconds = 0,
                                                WorldTimeZone worldTimeZone = WorldTimeZone.TaipeiStandardTime)
        {
            ChangeToDaily(timer, new TimeSpan(dueHours, dueMinutes, dueSeconds), worldTimeZone);
        }


        /// <summary>
        /// 變更計時器每日執行方法的時間。
        /// </summary>
        /// <param name="timer"></param>
        /// <param name="dueTime">每天執行方法的時間</param>
        /// <param name="worldTimeZone">開始時間的目標時區。</param>
        public static void ChangeToDaily(this Timer timer,
                                                TimeSpan duetime,
                                                WorldTimeZone worldTimeZone = WorldTimeZone.TaipeiStandardTime)
        {
            //每天執行方法的時間(指定時區)。減2天避免指定時區的日期超過Local時區的今天。
            var dueDateTime = DateTime.Now.Date.AddDays(-2).ToLocalTime(worldTimeZone).AddTicks(duetime.Ticks);
            //將執行方法的時間調整至今天，如果今天的時間已過則調整至明天。
            var fixDays = -1;
            while (dueDateTime.AddDays(++fixDays) < DateTime.Now) ;
            //執行方法的時間間隔。
            var dueTimeSpan = dueDateTime.Subtract(DateTime.Now) + TimeSpan.FromDays(fixDays);

            timer.Change(dueTimeSpan, TimeSpan.FromDays(1));
        }
    }
}

