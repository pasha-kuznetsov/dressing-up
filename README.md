Building
========

Use Visual Studio 2015+ to build `DressingUp.exe`

Running
=======

Pass input in command line.

Success:

    > DressingUp.exe HOT 8, 6, 4, 2, 1, 7
    Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house

    > DressingUp.exe COLD 8, 6, 3, 4, 2, 5, 1, 7
    Removing PJs, pants, socks, shirt, hat, jacket, boots, leaving house

Failure:

    > DressingUp.exe HOT 8, 6, 6
    Removing PJs, shorts, fail

    > DressingUp.exe HOT 8, 6, 3
    Removing PJs, shorts, fail

    > DressingUp.exe COLD 8, 6, 3, 4, 2, 5, 7
    Removing PJs, pants, socks, shirt, hat, jacket, fail

    > COLD 6
    fail

Additional failures:

    > 8
    fail

    > HOT8, 6
    fail
