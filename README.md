<p align="center">
<img src="https://media.giphy.com/media/SGLkvW0dExEgX2fD0a/giphy.gif" alt="ARPointer animation" title="ARPointer GIF" width="100%"/>
</p>

# About

AR Pointer is a software utility developed to assist developers in identifying the direction of the ARCamera in Augmented Reality. As most AR applications necessitate a guide to direct users on content placement and AR navigation, the AR Pointer provides an optimal solution for developers who prioritize the swift development of AR experiences.

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
   
ARPointer is a utility that is dependent on ARFoundation, and therefore, cannot function without it. The installation of the ARFoundation package is a necessary prerequisite for ARPointer to operate as intended.

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

By default, ARPointerController is activated, but if it happens to be deactivated, the corresponding method can be invoked to enable it.

```ARPointerController.EnablePointer();```

ARPointerController is executed within an Update loop, and it is recommended to disable it once it has served its purpose. To deactivate ARPointerController, please invoke the designated function.

```ARPointerController.DisablePointer();```

In order to insert a Prefab Object onto the scene or an AR plane, please invoke this method. Please note that the Prefab Object parameter must not be null, and that ARPointerController must be directed towards a trackable entity.

```ARPointerController.PlaceObject();```

Please be advised that only specific GameObjects are permitted to be placed onto the trackable surface. Although the example scene designates Unity's primitive GameObject cube as the default option, it is possible to define any alternative object as the default or choose to leave it null and assign it during runtime. To implement this, please call the corresponding method.

``` 
[SerializeField] private GameObject _anyObject;

ARPointerController.SelectObject(_anyObject); 
```

Once an object has been placed onto the ground, it can be returned to the selection menu by simply tapping on it. Please note that the object must possess both a rigidbody component and a collider component in order to register the click event.
