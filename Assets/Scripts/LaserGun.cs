using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private Animator laserAnimator;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField] private Transform raycastOrigin;

    private Vector3[] linePoints = new Vector3[2];

    public float lineDuration = 1f; // The duration (in seconds) that the line should be visible

    public LineRenderer lineRenderer;
    private AudioSource laserAudioSource;
    public float laserWidth = 0.01f;
    public float laserMaxLength = 500f;
    private RaycastHit hit;

    void Start() 
    {
        raycastOrigin = transform;
        lineRenderer = GetComponent<LineRenderer>();

    }
    
    private void Awake()
    {
        laserAudioSource = GetComponent<AudioSource>();
    }

    public void LaserGunFired()
    {
        //animate the gun 
        laserAnimator.SetTrigger("Fire");

        //play laser gun SFX
        laserAudioSource.PlayOneShot(laserSFX);

        lineRenderer.enabled = true;

        
        //RayCast
        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 1000f))
        {
            
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, new Vector3(raycastOrigin.position.x, raycastOrigin.position.y+0.05f, raycastOrigin.position.z));
            lineRenderer.SetPosition(1, hit.point);
                    
            
            if(hit.transform.GetComponent<AlienHit>() != null)
            {
                hit.transform.GetComponent<AlienHit>().alienDestroyed();
            }

            StartCoroutine(DisableLineRenderer());

        }
    }

    private IEnumerator DisableLineRenderer()
    {
        yield return new WaitForSeconds(lineDuration);
        lineRenderer.enabled = false;
    }
}