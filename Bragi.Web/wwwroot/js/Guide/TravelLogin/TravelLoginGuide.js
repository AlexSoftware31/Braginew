
const {
    hello,
    welcome,
    isFirstTitle,
    isFirstBody,
    next,
    back,
    done,
    close,
    questionTitle,
    questionBody,
    responseTitle,
    responseBody,
    withMorePassengersTitle,
    withModePassengersBody,
    catchaText,
    btnRequest,
    accessTitle,
    accessBody,
    questionAccess,
    questionResponseAccess,
    btnAccess,
    applicationCode
} = getTraslationsGuide();

const TravelLoginGuide = () => {
    var driver = new Driver({
        animate: true,
        nextBtnText: next,
        prevBtnText: back,
        doneBtnText: done,
        closeBtnText: close
    });
    driver.defineSteps([{
        element: '.guide-1',
        popover: {
            title: `<em>${welcome}</em>`,
            description: hello,
            position: 'top'

        }
    },
    {
        element: '.guide-2',
        popover: {
            title: `<em>${isFirstTitle}</em>`,
            description: isFirstBody,
            position: 'top'

        }
    },
    {
        element: '.guide-3',
        popover: {
            title: `<em>${questionTitle}</em>`,
            description: questionBody,
            position: 'top'

        }
    },
    {
        element: '.guide-4',
        popover: {
            title: `<em>${responseTitle}</em>`,
            description: responseBody,
            position: 'top'

        }
    },
    {
        element: '.guide-5',
        popover: {
            title: `<em>${withMorePassengersTitle}</em>`,
            description: withModePassengersBody,
            position: 'top'

        }
    },
    {
        element: '.guide-7',
        popover: {
            title: `<em></em>`,
            description: catchaText,
            position: 'top'

        }
    },
    {
        element: '.guide-8',
        popover: {
            title: `<em></em>`,
            description: btnRequest,
            position: 'top'

        }
    },
    {
        element: '.guide-9',
        popover: {
            title: `<em>${accessTitle}</em>`,
            description: accessBody,
            position: 'top'

        }
    },
    {
        element: '.guide-10',
        popover: {
            title: `<em></em>`,
            description: applicationCode,
            position: 'top'

        }
    },
    {
        element: '.guide-11',
        popover: {
            title: `<em></em>`,
            description: questionAccess,
            position: 'top'

        }
    },
    {
        element: '.guide-12',
        popover: {
            title: `<em></em>`,
            description: questionResponseAccess,
            position: 'top'

        }
    },
    {
        element: '.guide-13',
        popover: {
            title: `<em></em>`,
            description: btnAccess,
            position: 'top'

        }
    }]);
    driver.start();
};
