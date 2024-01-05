using MaterialSkin.Controls;

namespace TinyBin.Source.Data
{
    internal class ButtonState
    {
        public static void ChangeState(MaterialButton materialButtonGET)
        {
            if(materialButtonGET.Type == MaterialButton.MaterialButtonType.Contained)
            {
                //filled -> button active -> inactive()
                Inactive(materialButtonGET);
            }
            else if(materialButtonGET.Type == MaterialButton.MaterialButtonType.Outlined)
            {
                //outlined -> button inactive -> active()
                Active(materialButtonGET);
            }
        }

        public static void Active(MaterialButton materialButtonGET)
        {
            materialButtonGET.Type = MaterialButton.MaterialButtonType.Contained;
            materialButtonGET.UseAccentColor = false;
            materialButtonGET.DrawShadows = true;
        }
        public static void Inactive(MaterialButton materialButtonGET)
        {
            materialButtonGET.Type = MaterialButton.MaterialButtonType.Outlined;
            materialButtonGET.UseAccentColor = true;
        }

        public static bool ButtonIsActive(MaterialButton materialButtonGET)
        {
            bool result = false;
            if (materialButtonGET.Type == MaterialButton.MaterialButtonType.Contained)
            {
                result = true;
            }
            if (materialButtonGET.Type == MaterialButton.MaterialButtonType.Outlined)
            {
                result = false;
            }

            return result;
        }

        public static void ChangeStateByBool(MaterialButton materialButtonGET, bool checker)
        {
            if (!checker)
            {
                //filled -> button active -> inactive()
                Inactive(materialButtonGET);
            }
            else
            {
                //outlined -> button inactive -> active()
                Active(materialButtonGET);
            }
        }
    }
}
