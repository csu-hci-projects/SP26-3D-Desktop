# NodeDesk VR
Joshua Weihe

3 Min Video: https://youtu.be/i3NdysBbQxY 

Presentation Video: https://youtu.be/ZvErjKgi4h0

Code Video: https://youtu.be/7mPxY7U2c3g


A spatially organized Focus View navigation system in a VR desktop environment for traversing interconnected information networks.

---

## Project Overview

NodeDesk VR is a Unity-based virtual reality desktop prototype that explores how spatial organization and graph-relative traversal can improve repeated navigation through interconnected information.

The system allows users to:

- Create floating spatial nodes
- Arrange nodes in 3D space
- Create persistent links between nodes
- Enter a Focus View mode for local readability
- Traverse linked nodes using joystick input
- Delete nodes using a spatial trash-can interaction

The central research contribution is the Focus View traversal system, where joystick navigation directions are determined by the original authored spatial graph layout rather than the temporary enlarged presentation position of nodes during Focus View.

---

## Research Hypothesis

> A spatially organized Focus View navigation system in a VR desktop environment may improve navigation efficiency during repeated traversal of interconnected information networks.

---

## Core Features

### Spatial Node Workspace
Users can create and position note-like nodes throughout a room-scale VR workspace.

### Dynamic Linking
Nodes can be linked together using explicit graph connections rendered with visible line relationships.

### Wrist-Mounted Interface
A left-hand wrist UI allows users to:
- Create nodes
- Enter link mode
- Enter Focus View
- Control workspace interactions

### Focus View
Focus View enlarges the currently selected node in front of the user to improve readability while preserving graph-relative traversal semantics.

### Graph-Relative Traversal
Joystick input is interpreted relative to the original authored spatial graph layout.

Example:
- If a linked node exists to the left in the authored graph, pushing the joystick left will traverse to that node even while the current node is enlarged in Focus View.

---

# Hardware

- Meta Quest 2
- Meta Quest controllers
- Unity XR Interaction Toolkit

---

# Software Stack

- Unity
- C#
- XR Interaction Toolkit
- TextMeshPro

---

# Repository Structure

Assets/
    Scripts/
    Prefabs/
    Scenes/
    Materials/
    XR/

Documentation/
Research/
Media/
Builds/

---

# Main Unity Scripts

| Script | Purpose |
|---|---|
| `NodeDeskManager.cs` | Main workspace manager |
| `NodePanel.cs` | Stores node content and display behavior |
| `NodeSelectable.cs` | Handles node interaction and selection |
| `NodeLink.cs` | Stores and renders node relationships |
| `LinkManager.cs` | Handles link creation logic |
| `FocusViewManager.cs` | Handles Focus View transitions and traversal |
| `TrashCan.cs` | Handles node deletion interactions |

---

# Controls

| Action | Input |
|---|---|
| Grab/move node | Controller lower trigger |
| Press UI buttons | Controller upper trigger |
| Create node | Wrist menu button |
| Create link | Wrist menu button |
| Enter Focus View | Wrist menu button |
| Traverse nodes | Left joystick |
| Delete node | Move node into trash can |

---

# Building the Project

## Requirements

- Unity version: `[INSERT UNITY VERSION]`
- XR Interaction Toolkit
- Meta XR plugins if used

## Build Steps

1. Open the Unity project.
2. Open the main scene:
   `[INSERT MAIN SCENE NAME]`
3. Ensure XR Plug-in Management is enabled.
4. Switch platform to Android.
5. Build and Run to Meta Quest 2.

---

# Research Study

This repository also contains the complete research study associated with the NodeDesk VR prototype.

Included materials:
- ACM-format research paper
- Participant protocol forms
- Combined participant protocol document
- Participant observations
- Likert-scale survey results
- Figures and screenshots
- References and bibliography
- LaTeX source files

---

# Participant Data

All scanned participant protocol forms are included in the repository.

Additionally:
- A combined participant-protocol document containing all participant forms is included.
- Raw Likert-scale questionnaire data is included.
- Qualitative observation notes are included.

Participant identifiers were anonymized using labels:
- P1
- P2
- P3
- P4
- P5
- P6

---

# Key Findings

## Positive Findings

Participants generally:
- Found spatial node arrangement intuitive
- Understood graph-relative joystick traversal
- Enjoyed direct node manipulation
- Treated the workspace as a conceptual map

## Major Issues Observed

### Focus View Scale
Several participants reported that Focus View felt:
- too close
- too large
- visually abrupt

### Hardware Limitations
Multiple participants reported:
- headset fogging
- limited field of view
- visual blur

### Dense Graph Problems
One participant created a highly connected graph which became difficult to navigate.

Future versions should likely:
- limit node links to approximately four neighbors
- improve traversal disambiguation
- add animated transitions

---

# Future Work

Potential future improvements include:
- Smooth animated transitions
- Adjustable Focus View distance
- Semantic node clustering
- AI-assisted node organization
- Interactive applications/windows
- Multi-user collaboration
- Typed graph links
- Search and filtering systems
- Mini-map visualization
- Mixed reality integration

---

# Media

Replace this section with:
- gameplay screenshots
- traversal GIFs
- study photos
- demo videos

Example:

Media/
    screenshots/
    demo_video.mp4
    traversal_demo.gif

---

# Research Paper

The complete ACM-format research paper is included in:

Research/final_report.tex

Bibliography file:

Research/references.bib

Compiled PDF:

Research/final_report.pdf

---

# Citation

[INSERT FINAL CITATION]

---

# Acknowledgements

Colorado State University  
CS 465 – 3D Multimodal Human Computer Interaction

Additional references and related work are cited in the included ACM-format paper.
