dud.start(() => {

    /*  
     
        Add stars around each character. 
        
        Extra: Solve this exercise in four ways:
         - "for" loop
         - "for in" loop
         - "for of" loop
         - using "map"

    */


    dud.run({},
        [
            {
                input: "ab",
                expected: ["*a*", "*b*"]
            },

            {
                input: "XYZ",
                expected: ["*X*", "*Y*", "*Z*"]
            },

            {
                input: "",
                expected: []
            }
        ],
        starify,
        starify_forIn,
        starify_forOf,
        starify_map
    );

    /* 
     
        Add one to each number in the list

        Extra: create two solutions. One should use "map"

    */

    dud.run({},
        [
            {
                input: [2, 5, 8],
                expected: [3, 6, 9]
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
        addOneToEachNumber,
        addOneToEachNumber_map
    );


    /*
     
        Put the last element first in the array
        
        Extra: Create two solutions. One should use "pop"

    */

    dud.run({},
        [
            {
                input: [1, 2, 3, 4],
                expected: [4, 1, 2, 3]
            },
            {
                input: [1, 2, 3],
                expected: [3, 1, 2]
            },
            {
                input: [],
                expected: []
            }
        ],
        putTheLastElementFirst,
        putTheLastElementFirst_pop,
    );

    /* 
     
        Add the numbers in the list and put chars around the side of the resulting string
        
        Extra: Create two solutions. One should use "spread operator"

    */

    dud.run({ multipleParameters: true },
        [
            {
                input: ["<", ">", 3, 4, 5],
                expected: "<12>"
            },

            {
                input: ["[", "]", 55, 2],
                expected: "[57]"
            },

            {
                input: ["A", "B", 6],
                expected: "A6B"
            }
        ],
        supersum,
        supersum_spread,
    );


    /* 
     
        Change some of the strings in the array to uppercase 

        Extra: Create two solutions. One should use "map"

    */

    dud.run({ multipleParameters: true },
        [
            {
                input: [["what", "does", "the", "fox", "says"], [true, true, false, false, true]],
                expected: ["WHAT", "DOES", "the", "fox", "SAYS"]
            },
            {
                input: [["what", "does", "the", "fox", "says"], [false, false, false, true, false]],
                expected: ["what", "does", "the", "FOX", "says"]
            },
            // If there are too many element in the first or second element => return null
            {
                input: [["what", "does"], [false]],
                expected: null
            },
            {
                input: [["what"], [false, false]],
                expected: null
            }
        ],
        someUpperCase,
        someUpperCase_map
    );

    dud.render()

})
