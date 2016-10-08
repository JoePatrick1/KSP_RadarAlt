using UnityEngine;
using KSP.UI.Screens.Flight;

namespace RadarAltimeter
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class AltimeterSwitch : MonoBehaviour
    {
        public double radarAlt;
        public double alt;
        public AltitudeTumbler altTumbler;
        public bool radarMode;
        public float keyCheck;

        public void Start()
        {
            altTumbler = FindObjectOfType<AltitudeTumbler>();
        }

        public void Update() {
            if (Input.GetKeyDown(KeyCode.BackQuote))
                radarMode = !radarMode;

            alt = FlightGlobals.ActiveVessel.altitude;
            if (alt < 0) radarMode = false;

            if (radarMode)
            {
                radarAlt = FlightGlobals.ActiveVessel.radarAltitude;
                altTumbler.tumbler.SetColor(new Color32(15, 35, 120, 255));
                altTumbler.tumbler.SetValue(radarAlt);
            }
            else if (alt > 0)
            {
                altTumbler.tumbler.SetColor(Color.black);
            }
        }


    }
}
