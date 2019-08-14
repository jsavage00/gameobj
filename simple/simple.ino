#include "MPU9250.h"
#include "eeprom_utils.h"

MPU9250 mpu;


int ledPin = 13; // choose the pin for the LED
int inPin = 8;   // choose the input pin (for a pushbutton)
int val = 0;     // variable for reading the pin status


void calibrate() {
   mpu.setup();
  mpu.setMagneticDeclination(-0.2);
  mpu.calibrateAccelGyro();
  mpu.calibrateMag();

  // save to eeprom
  saveCalibration();

  // load from eeprom
  loadCalibration();
}


void setup()
{
  
  Serial.begin(115200);

  Wire.begin();
  mpu.setup();
  //calibrate();
  delay(2000);
    
}

void loop()
{
    static uint32_t prev_ms = millis();
    if ((millis() - prev_ms) > 16)
    {
      mpu.update();
      //mpu.print();


      Serial.print(mpu.getRoll());
      Serial.print("|");
      Serial.print(mpu.getPitch());
      Serial.print("|");
      Serial.println(mpu.getYaw());

      prev_ms = millis();
    }
}
