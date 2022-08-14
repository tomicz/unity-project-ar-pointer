<p align="center">
<img src="https://media.giphy.com/media/1Zxd7MF4QMdurxkpn5/giphy.gif" alt="ARPointer animation" title="ARPointer GIF" width="500"/>
</p>

<img src="https://media.giphy.com/media/UVAtvQ3QHAz8g9CbsH/giphy.gif" width="300">
# About

AR Pointer is a helper tool made for developers that indicates where the ARCamera is pointing in Augmented Reality. Most AR experiences at some point will require an indicator that guides the user on where to place content or how to navigate AR applications. AR Pointer is a perfect solution for developers who prefer rapidly developing AR experiences.

### Requirements

  * <b>ARFoundation</b> - is the only and best solution for AR apps, and it runs on Android and iOS.
  * <b>Unity 2019+</b>
  
### Features

  * Detect trackables (ARPlane)
  * Move selected object
  * Place selected object onto ARPlane
  * Grab placed object and return it to selection
  * Enable/Disable pointer (it's a good practice to disable pointer when is not used to save on performance, because AR applications are performance hungry).

## Getting started
   
ARPointer is built on top of ARFoundation and it will not work without it. It is required to install ARFoundation package in order for ARPointer to function properly. 

 * Install ARFoundation package.
 * Import ARPointer folder to your project.
 * Setup AR project - If you don't know how, follow this link [ARFoundation - Setup](https://learn.unity.com/tutorial/setting-up-ar-foundation)
 * Attach ARPointerController to AR Session Origin gameObject in the hierarchy.
    * **Trackable Types** are the types that the pointer can detect. To track horizontal or vertical planes, select Plane With Bounds. 
    * **Prefab Object** is any gameObject that you want to place onto a trackable.
    * **Tracking lost offset** is an offset of Prefab Object from camera when tracking is lost. This is a good practice to inform user that tracking is lost.


 * On the gameObject AR Session Origin, on the attached class AR Pointer controller you will notice two exposed unity events.
    * On Trackable Found Event - Do something when tracking is found
    * On Trackable Lost Event - Do something when tracking is lost


###### If this section is not helpful enough, I provided you with an example scene. Please have a look at it. 

### Code snipets

ARPointerController is enabled by default, but if it is disabled, you can call this method to enable it.

```ARPointerController.EnablePointer();```

ARPointerController is running in an Update loop and it's a good practice to disable it after you don't need it. Call this function to disable it.

```ARPointerController.DisablePointer();```

To place an object (Prefab Object) into the scene/ arplane, call this method. Prefab Object cannot be null and ARPointerController has to point at a trackable.

```ARPointerController.PlaceObject();```

Only selected GameObjects can be placed on the trackable surface. In the example scene you can notice that unity's primitive GameObeject cube is selected by defaut, but you can set any object as default or even leave it null and add it at runtime. To do that call this method.

``` 
[SerializeField] private GameObject _anyObject;

ARPointerController.SelectObject(_anyObject); 
```
