dud.start(() => {

    /* 
     
     Pick every second element from the list. 
     
     Extra: create two solutions. One using "filter". 

    */

    dud.run({},
        [
            {
                input: [1, 2, 3, 4],
                expected: [2, 4]
            },

            {
                input: ['A', 'B', 'C', 'D'],
                expected: ['B', 'D']
            },

            {
                input: ['A', 'B'],
                expected: ['B']
            },

            {
                input: [],
                expected: []
            },

            {
                input: null,
                expected: null
            }
        ],
        pickEverySecond,
        pickEverySecond_withFilter,
        pickEverySecond_withFilter2,
        pickEverySecond_withFilter3,

    );

    /*

    Tell the type of the parameter (string, number etc). Return a string as seen below

    Extra: create three solutions:
    - with "if"
    - with "switch"
    - without if or switch or conditional if

    */


    let anUndefinedValue

    dud.run({},
        [
            {
                input: 30,
                expected: "A number 30. Add 70 and you will get 100."
            },
            {
                input: 90,
                expected: "A number 90. Add 10 and you will get 100."
            },
            {
                input: 110,
                expected: "A number 110. It is greater or equal to 100."
            },
            {
                input: true,
                expected: "It is true"
            },
            {
                input: false,
                expected: "It is false"
            },
            {
                input: "Musse",
                expected: "Just a string"
            },
            {
                input: anUndefinedValue,
                expected: "Not defined"
            }
        ],
        tellType,
        tellType_switch,
        tellType_withoutIfOrSwitch
    );

    /*
    
    Create a shoppinglist from the inputed values as you see below.
    
    Extra: create three solutions, one with "map" and one "oneliner"
    
    */

    dud.run({},
        [
            {
                input: ["Screw", "Hammer", "Wrench"],
                expected: "TO BUY: * SCREW * HAMMER * WRENCH"
            },

            {
                input: ["Screw", "Hammer"],
                expected: "TO BUY: * SCREW * HAMMER"
            },

            {
                input: ["Screw"],
                expected: "TO BUY: * SCREW"
            },

            {
                input: [],
                expected: "NOTHING TO BUY"
            }
        ],
        shoppinglist,
        shoppinglist_map,
        shoppinglist_oneline
    );

    /*
    
    Create a sequence with a startvalue and some settings. See the examples
    
    Extra: create two solutions, one with "for" and one with "while"
    
    */

    dud.run({ multipleParameters: true },
        [
            /* Start with 10. Increase 2 each time. End when you have 5 element.*/
            {
                input: [10, 2, 5],
                expected: [10, 12, 14, 16, 18]
            },
            /* Start with 98. Increase 1 each time. End when you have 7 element.*/
            {
                input: [98, 1, 7],
                expected: [98, 99, 100, 101, 102, 103, 104]
            },
            /* I don't want any elements.*/
            {
                input: [98, 1, 0],
                expected: []
            }
        ],
        createSequence,
        createSequence_while
    );

    /*

    Create a method that return a person as a object. Some of the properties should be calculated. See below

    */

    dud.runfun("createPerson", (f) => {

        let person = f("Johan", "Rheborg", ['Percy Nilegård', 'Farbror Barbro', 'Kenny Starfighter'])

        dud.assert("Johan", person.firstName)
        dud.assert("Rheborg", person.lastName)

        dud.assert(['Percy Nilegård', 'Farbror Barbro', 'Kenny Starfighter'], person.characters)
        dud.assert("Johan Rheborg", person.fullName())
        dud.assert(3, person.numberOfRoles())

        person.firstName = "A"
        person.lastName = "B"
        person.characters = ['X', 'Y']

        dud.assert("A", person.firstName)
        dud.assert("B", person.lastName)
        dud.assert(['X', 'Y'], person.characters)
        dud.assert("A B", person.fullName())
        dud.assert(2, person.numberOfRoles())

    },
        createPerson,
    );

    /*

    Same as above, but use "getter". 

    Notice that "fullName" and "numberOfRoles" is called different than above.

    */

    dud.runfun("createPersonGetter", (f) => {

        let person = f("Johan", "Rheborg", ['Percy Nilegård', 'Farbror Barbro', 'Kenny Starfighter'])

        dud.assert("Johan", person.firstName)
        dud.assert("Rheborg", person.lastName)

        dud.assert(['Percy Nilegård', 'Farbror Barbro', 'Kenny Starfighter'], person.characters)
        dud.assert("Johan Rheborg", person.fullName)
        dud.assert(3, person.numberOfRoles)

        person.firstName = "A"
        person.lastName = "B"
        person.characters = ['X', 'Y']

        dud.assert("A", person.firstName)
        dud.assert("B", person.lastName)
        dud.assert(['X', 'Y'], person.characters)
        dud.assert("A B", person.fullName)
        dud.assert(2, person.numberOfRoles)

    },
        createPersonGetter,
    );

    dud.render()

})
