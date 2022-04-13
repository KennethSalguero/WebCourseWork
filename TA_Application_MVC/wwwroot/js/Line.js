/**
 * Author:    Kenneth Salguero u1021533
 * Partner:   None
 * Date:      11/22/2021
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and [Your Name(s)] - This work may not be copied for use in Academic Coursework.
 *
 * I, Kenneth Salguero, certify that I wrote this code from scratch and did
 * not copy it in part or whole from another source.  Any references used
 * in the completion of the assignment are cited in my README file and in
 * the appropriate method header.
 *
 * File Contents
 *
 *    A class representing a line.
 */
class Line extends PIXI.Graphics {
    constructor(x, y) {
        super();
        this.beginFill(0x000000);
        this.drawRect(0, 0, 765, 1);
        this.x = 0;
        this.y = y;
    }
}