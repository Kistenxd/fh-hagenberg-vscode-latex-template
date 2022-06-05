# Latex template

This is a vs code latex template that uses the template https://github.com/Digital-Media/HagenbergThesis and wraps it in a vs code workspace.

This template comes with Syntax Highlighting for code by using the minted package.

The hgbListings.sty has been replaced by CustomListings.sty which sets up minted, changes the mono font to JetBrains Mono and does some minor adjustments.

## Requirements

* Docker
* LaTex Workshop - VS Code extension

## Setup

For this template to work, docker needs to be running and the vs code extension LaTeX Workshop needs to be installed.
If docker is running, use the dockerfile to create a docker container. 

Whenever something in a file referenced by main.tex is saved, the pdf should be generated. Make sure, that you open the workspace and not just the folder in VS Code
