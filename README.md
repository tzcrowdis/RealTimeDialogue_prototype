# RealTimeDialogue_prototype

This prototype boils down dialogue tree splits into just 5/6 questions (who, what, when, where, why, and sometimes waited). The only one which may not be self explanatory is waited which is for making the NPC wait too long. This trades off answer complexity for urgency which will hopefully lead to a more natural feeling conversation time. Consequences can be inserted via dialogue, i.e. ask a nonsense/inappropriate question and you could hurt your rapport with the NPC. Other consequences can also be tracked via a consequence manager that keeps records of whether some game events have been triggered via dialogue. This system could work great in a detective/mystery setting.


Script is designed to be placed on every text object so that all creative work can be done in the unity editor.


## Future Directions:
- consequence management system DONE?
- handle player spamming input
- better way to check current than in update?
- develop simple demo level


Developed in Unity version 2021.3.1f1
