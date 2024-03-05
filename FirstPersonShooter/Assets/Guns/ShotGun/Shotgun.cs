using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun

{
    protected override void PrimaryFire()
    {
        if (shoot_delay_timer <= 0)
        {
            if (primary_fire_is_shooting || primary_fire_hold)
            {
                //Delay gun from shooting again.
                shoot_delay_timer = gun_data.primary_fire_delay;
                primary_fire_is_shooting = false;

               //have code repeat itself, at the start of the loop. i=0 is where it starts, we are declaring it to be 0. then it will go until it becomes greater that 6. then loop.
                for(int  i = 0; i < 6; i++)
                {

                }

                //Set direction of the ray.
                Vector3 dir = Quaternion.AngleAxis(Random.Range(-gun_data.spread, gun_data.spread), Vector3.up) * cam.transform.forward;
                dir = Quaternion.AngleAxis(Random.Range(-gun_data.spread, gun_data.spread), Vector3.right) * dir;

                //Raycast
                ray = new Ray(cam.transform.position, dir);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, gun_data.range))
                {
                    //Draw ray to demostrate how shooting might look like.
                    Debug.DrawLine(transform.position, hit.point, Color.green, 0.05f);
                }

                //Ammo
                ammo_in_clip--;
                if (ammo_in_clip <= 0) ammo_in_clip = gun_data.ammo_per_clip;
            }
        }
    }
}

