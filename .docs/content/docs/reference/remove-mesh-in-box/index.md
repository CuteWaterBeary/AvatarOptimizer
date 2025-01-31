---
title: Remove Mesh in Box
weight: 25
---

# Remove Mesh in Box

Remove some polygons in any of specified boxes.

This component is [Modifying Edit Skinned Mesh Component](../../component-kind/edit-skinned-mesh-components#modifying-component), so this should be added to a GameObject which has a SkinnedMeshRenderer component.

## Settings

Adjust the value to add box.
For each box, you can change the center Position, Size, and Rotation of the box. (In local coordinate)

![component.png](component.png)

Click `Edit This Box` to show Gizmo to edit the box like below. You can scale, move and rotate the box.

<img src="gizmo.png" width="563">

## Example

With boxes shown on upper image, meshes in the box will be removed as lower image shows.

<img src="before.png" width="403">
<img src="after.png" width="403">
