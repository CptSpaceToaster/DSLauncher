##DSLauncher.net
A .net and java Minecraft Wrapper for the Dungeons and Shotguns
Gaming community.  It is primarily used to run and update
a Portable Forge Minecraft Client to keep it in sync with the 
DS Minecraft Server.

If you would like to use any of this code to build your 
own launcher feel free. We will warn you that the code in
this project may not be the best.  Clean up may be required.

In its current state, there is a heap of old code and some
more recent additions all mixed together.  We now only use the
.net exe to redirect the Minecraft launcher and launch a Java 
based auto updater.  This basically means that the exe is just 
a high end replacment for a batch file or script.
(this allows us to asign an icon in windows).

The change means that our launcher should now be mono compliant
and we should not break when Mojang makes changes to their launcher
or login process.

The old launcher is in the 2.0 branch if you would like to use the old 
code.
