# RealTimeDialogue_prototype

This prototype boils down dialogue tree splits into just 5(6) questions (who, what, when, where, why, and sometimes waited). The only one which may not be self explanatory is waited which is for making the NPC wait too long. This trades off answer complexity for urgency which will hopefully lead to a more natural feeling conversation time. Consequences can be inserted via dialogue, i.e. ask a nonsense/inappropriate question and you could hurt your rapport with the NPC. Other consequences can also be tracked via a consequence tracker that keeps record of whether some game events have been triggered via dialogue. This system could work great in a detective/mystery setting.

The demo folder contains a scene demonstrating the capabilities of this system. Not a deep fleshing out of the dialogue system, only handles some expected behavior, but demonstrates how consequences can be used in dialogue and in the world.

The dialogueNPC script is designed to be placed on each text object so that all creative work can be done in the unity editor. The consequence scripts are designed to be placed on the overlay.


## To Do:
- handle player spamming input
- better way to check current than in update?

### Misc
- Developed in Unity version 2021.3.1f1
- Modular FPS Controller: https://assetstore.unity.com/packages/3d/characters/modular-first-person-controller-189884
