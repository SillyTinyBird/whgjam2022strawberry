using UnityEngine.UI;

class Fading
{
        /// <summary> Fade in the image </summary>
        /// <param name="img"> Image, that is going to be faded</param>
        /// <param name="fadeSpeed">Speed of the fade</param>
        public static void FadeIn(Image img, float fadeSpeed) => img.CrossFadeAlpha(1, fadeSpeed, true);

        /// <summary> Fade out the image </summary>
        /// <param name="img"> Image, that is going to be faded</param>
        /// <param name="fadeSpeed">Speed of the fade</param>
        public static void FadeOut(Image img, float fadeSpeed) => img.CrossFadeAlpha(0, fadeSpeed, true);
}

