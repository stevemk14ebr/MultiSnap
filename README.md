# MultiSnap - A Multi Monitor AeroSnap alternative

Windows default aerosnap feature is broken for multimonitor setups. This tool emulates aerosnaps behavior in a way that makes the experience much more comfortable on multi monitor setups. 

#Why?
On AMD multi-monitor setups the screen is presented to the windows OS as one large display. As a consequence the aero-snap feature built into windows OS that allows you to quickly re-size applications by dragging them to a screen edge doesn't properly align applications to the screen borders. Often times when maximizing a window a user wants to maximize it in only the current screen, rather than across all the screens of a multi-monitor system. Windows OS by default offers no way to customize where applications snap to or how they are sized. This tool is meant to completely replace windows Aero-Snap and offers users the ability to create custom rules that define when applications get resized, and the size/position of the applications after resizing.

#Usage
Simply start the application, click create new snap and then double click on the overlay that shows up to create your snapping rules. The first rectangle you create will be the location of where you drag the window into, and the second rectangle will be where the window is snapped to on your desktop. You can have an infinite number of rules, each being saved in an XML file when the form closes. Rules are stored as percentages of screen width and height to allow users to share rules. You can manually modify the xml and the application will read the new rules in upon application restart.

![alt tag](http://i.imgur.com/Sy5vL5n.gif)
