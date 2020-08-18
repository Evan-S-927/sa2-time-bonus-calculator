using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeBonusCalculator
{
    public partial class TimeBonusCalculator : Form
    {
        public TimeBonusCalculator()
        {
            InitializeComponent();
        }

        private void Btn_Convert_Click(object sender, EventArgs e)
        {
            int userMinutes = 0;
            int userSeconds = 0;
            int seconds = 0;
            int bonus = 0;

            if(txt_ConvertMinute.Text.Trim() != "")
                userMinutes = Convert.ToInt32(txt_ConvertMinute.Text.Trim());

            if (txt_ConvertSecond.Text.Trim() != "")
                userSeconds = Convert.ToInt32(txt_ConvertSecond.Text.Trim());

            seconds = TimeToSeconds(userMinutes, userSeconds);
            bonus = TimeToBonus(seconds);
            txt_TimeBonus.Text = Convert.ToString(bonus);
        }

        private void Btn_Check_Click(object sender, EventArgs e)
        {
            int userMinutes = 0;
            int userSeconds = 0;
            int currentScore = 0;
            int reqScore = 0;
            int scoreDifference = 0;
            int seconds = 0;
            int bonus = 0;

            if (txt_CheckMinute.Text.Trim() != "")
                userMinutes = Convert.ToInt32(txt_CheckMinute.Text.Trim());

            if (txt_CheckSecond.Text.Trim() != "")
                userSeconds = Convert.ToInt32(txt_CheckSecond.Text.Trim());

            if (txt_ScoreCurrent.Text.Trim() != "")
                currentScore = Convert.ToInt32(txt_ScoreCurrent.Text.Trim());

            if (txt_Req.Text.Trim() != "")
                reqScore = Convert.ToInt32(txt_Req.Text.Trim());

            seconds = TimeToSeconds(userMinutes, userSeconds);
            bonus = TimeToBonus(seconds);

            scoreDifference = (bonus + currentScore) - reqScore;

            if (scoreDifference == 0)
                txt_CheckResult.Text = "You have just enough points!";

            else if (scoreDifference > 0) {
                txt_CheckResult.Text = "You have ";
                txt_CheckResult.Text += Convert.ToString(scoreDifference);
                txt_CheckResult.Text += " extra points. (";
                scoreDifference /= 20;
                txt_CheckResult.Text += scoreDifference;
                txt_CheckResult.Text += " extra seconds)";
            }

            else if (scoreDifference < 0)
            {
                scoreDifference = Math.Abs(scoreDifference);
                txt_CheckResult.Text = "You're ";
                txt_CheckResult.Text += Convert.ToString(scoreDifference);
                txt_CheckResult.Text += " points short. (Be ";
                scoreDifference /= 20;
                txt_CheckResult.Text += scoreDifference;
                txt_CheckResult.Text += "s faster)";
            }
        }

        private int TimeToSeconds(int minutes, int seconds)
        {
            seconds += minutes * 60;
            return seconds;
        }

        private int TimeToBonus(int seconds)
        {
            int bonus = 10000;
            int penalty = 0;
            if(seconds > 60)
            {
                penalty = (seconds - 60);
                penalty *= 20;
                bonus -= penalty;
            }

            return bonus;
        }
    }
}
