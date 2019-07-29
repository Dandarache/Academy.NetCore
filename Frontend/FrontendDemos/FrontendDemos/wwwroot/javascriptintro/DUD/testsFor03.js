/*
  todo: skapa tester för klasser (t.ex att testa Shape)
  todo: skapa tester generators

 */

dud.start(() => {

    /* 
     
     Add 10 minutes to the time passed in to the method. Return a formatted as seen below 
     
     */

    dud.run({ multipleParameters: true },
        [
            // Add ten minutes to "2019-05-31 23:55"
            {
                input: [2019, 5, 31, 23, 55],
                expected: "2019-06-01 00:05"
            },
            // Add ten minutes to "2019-05-31 20:00"
            {
                input: [2019, 5, 31, 20, 0],
                expected: "2019-05-31 20:10"
            },
            // Add ten minutes to "2019-05-31 19:58"
            {
                input: [2019, 5, 31, 19, 58],
                expected: "2019-05-31 20:08"
            },
            // Add ten minutes to "2019-01-01 00:01"
            {
                input: [2019, 1, 1, 0, 1],
                expected: "2019-01-01 00:11"
            }
        ],
        addTenMinutes
    );

    /* 
     
    Add numbers from outside to in.  
    
    Extra: create two solution where one is using "recursion"

    */

    dud.run({},
        [

            {
                input: [5, 8, 2, 11],
                expected: [16, 10]       // 5+11, 8+2
            },

            {
                input: [1, 2, 3, 4, 5],
                expected: [6, 6, 3]       // 1+5, 2+4, 3
            },


            {
                input: [5, 8, 2],
                expected: [7, 8]
            },

            {
                input: [5, 8],
                expected: [13]
            },

            {
                input: [5],
                expected: [5]
            },
            {
                input: [],
                expected: []
            }
        ],
        addFromEdges,
        addFromEdges_recursive,

    );

    /* 
    
    Get the elements nearby a position 
    
    Extra: create more tests (for edgecases) and assert that your code is correct. 
    Return null if the function is called in wrong way

    */

    dud.run({ multipleParameters: true },
        [
            {
                input: [['a', 'b', 'c', 'd', 'e'], 3],
                expected: ['c', 'd', 'e']
            },

            {
                input: [['a', 'b', 'c', 'd', 'e'], 5],
                expected: ['d', 'e']
            },

            {
                input: [['a', 'b', 'c', 'd', 'e'], 1],
                expected: ['a', 'b']
            },

            // Extra exercise 

            {
                input: [['a', 'b'], 1],
                expected: ['a', 'b']
            },

            {
                input: [['a', 'b'], 2],
                expected: ['a', 'b']
            },

            {
                input: [['a'], 1],
                expected: ['a']
            },

            {
                input: [['a', 'b', 'c', 'd', 'e'], 6],
                expected: null
            },

            {
                input: [['a', 'b', 'c', 'd', 'e'], 0],
                expected: null
            }
        ],

        nearbyElement,
    );

    dud.render()

})
