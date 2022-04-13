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
 *    A class representing a rectangle.
 */
var red = 0xdb7272;
var blue = 0x7276db;
var currentColor;       // Tracks current color on mousedown
var mouse_down = false;

class Rectangle extends PIXI.Graphics {

    constructor(day, hour, available) {
        super();
        if (available) {
            this.beginFill(blue);
        }
        else {
            this.beginFill(red);
        }

        this.drawRect(0, 0, 100, 15);
        this.x = 150 * day + 50; // for days of the week
        this.y = 15 * hour + 100;
        this.interactive = true;

        // Fields
        this.day = day;
        this.hour = hour;
        this.available = available;

        this.on('mousedown', this.pointer_down);
        this.on('mouseover', this.pointer_over);
        this.on('mouseup', this.pointer_up);
    }

    pointer_down() {
        this.clear();

        // Toggle the color
        if (this.available) {
            currentColor = red;
            this.available = false;
        }
        else {
            currentColor = blue;
            this.available = true;
        }

        updateDB(this.available, this.day, this.hour);

        this.beginFill(currentColor);
        this.drawRect(0, 0, 100, 15);
        mouse_down = true;
    }

    pointer_up() {
        mouse_down = false;
    }

    pointer_over() {
        // If mouse down change the colors of squares hovering
        if (mouse_down) {
            this.clear();
            this.beginFill(currentColor);

            if (currentColor === blue) {
                this.available = true;
            }
            if (currentColor === red) {
                this.available = false;
            }
            updateDB(this.available, this.day, this.hour);
            this.drawRect(0, 0, 100, 15);
        }
    }
}