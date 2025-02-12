namespace PlannerA;
public class Commands
{
    public static void ScrollForward()
    {
        current_date = current_date.AddDays(1);
        UpdateDates();
        UpdateRows();
    }
    public static void SetToday()
    {
        current_date = DateOnly.FromDateTime(DateTime.Today);
        UpdateDates();
        UpdateRows();
    }
    public void ScrollBackward()
    {
        current_date = current_date.AddDays(-1);
        UpdateDates();
        UpdateRows();
    }
    public void ScrollWeek()
    {
        current_date = current_date.AddDays(7);
        UpdateDates();
        UpdateRows();
    }
}