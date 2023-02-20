# PROTransition

*Made with Unity 2020.3*

This Unity project is designed to make transitioning between screens easier by using some animations. It uses C# scripts to handle asynchronous scene loading and activation of fade animations. 



## Installation
To use this project, you will need to have Unity 2019 or later installed. You will also need to have Git installed on your computer.

To get started, clone this repository to your computer:
https://github.com/hansschaa/PROTransition

## Usage
This project is used to create a smooth transition between screens using fade animations. To use it, follow these steps:

1. Add Transition Manager Prefab to your scene (this gameobject have a TransitionScreenManager.cs singleton script)
2. Call "Play()" method in this script. You must to give a Transition object, see the demo example for more clarity.
3. ¿Who trigger the end animation to the transitions? This must called from the new scene loaded.
4. The scenes are load in a asynchronus way.
5. You can pass callbacks for end o begin transitions, see the demo example for more clarity, the console have usefull messages.


## Current Transitions
- Fade
<img src="https://user-images.githubusercontent.com/13873346/219246119-aa337f29-975b-4eec-abc4-c821c3e8334f.gif" width="50%" height="50%"/>

- Mask (Like Mario 64)
<img src="https://user-images.githubusercontent.com/13873346/219246691-bbe7537d-f78e-417f-a396-e94b7de904fe.gif" width="50%" height="50%"/>

- Filled Image Horizonta/Vertical
<img src="https://user-images.githubusercontent.com/13873346/220031536-21676f58-9d32-48f5-b8a2-5cb9c19ba5e5.gif" width="50%" height="50%"/>

- Others (WIP)

## Contributions
If you want to contribute to this project, feel free to send a pull request. Make sure to include a detailed description of the changes you have made and ensure your code adheres to Unity's style guidelines.
