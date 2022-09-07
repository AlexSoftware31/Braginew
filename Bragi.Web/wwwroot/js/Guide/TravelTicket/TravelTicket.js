
const {
    welcome,
    hello,
    next,
    back,
    done,
    close,
    guide2Title,
    guide2Body,
    guide3Body,
    guide3Title,
    isCommonTitle,
    isCommonBody,
    guide4Body,
    guide5Body,
    guide6Body,
    guide7Title,
    guide7Body,
    guide8Body,
    guide9Body,
    guide10Body

} = getTraslationsGuideTravelTicket();

const generalInformationGuide = () => {
    const driver = new Driver({
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
    }]);
    driver.start();
};

const migratoryInfomationGuide = () => {
    const driver = new Driver({
        animate: true,
        nextBtnText: next,
        prevBtnText: back,
        doneBtnText: done,
        closeBtnText: close
    });
    driver.defineSteps([
        {
            element: '.guide-2',
            popover: {
                title: `<em>${guide2Title}</em>`,
                description: guide2Body,
                position: 'top'
            }
        }]);
    driver.start();
};

const isCommonAddressGuide = () => {
    const x = new Driver({
        animate: true,
        nextBtnText: next,
        prevBtnText: back,
        doneBtnText: done,
        closeBtnText: close
    });
    x.defineSteps([
        {
            element: '.guide-2',
            popover: {
                title: `<em>${isCommonTitle}</em>`,
                description: isCommonBody,
                position: 'top'
            }
        }]);
    x.start();
};

const customsInformationGuide = () => {
    const driver = new Driver({
        animate: true,
        nextBtnText: next,
        prevBtnText: back,
        doneBtnText: done,
        closeBtnText: close
    });
    driver.defineSteps([
        {
            element: '.guide-3',
            popover: {
                title: `<em>${guide3Title}</em>`,
                description: guide3Body,
                position: 'top',
                className:'drive-popover-item'
            }
        },
        {
            element: '.guide-4',
            popover: {
                title: `<em></em>`,
                description: guide4Body,
                position: 'top'
            }
        },
        {
            element: '.guide-5',
            popover: {
                title: `<em></em>`,
                description: guide5Body,
                position: 'top'
            }
        },
        {
            element: '.guide-6',
            popover: {
                title: `<em></em>`,
                description: guide6Body,
                position: 'top'
            }
        }]);
    driver.start();
};

const publicHealtGuide = () => {
    const x = new Driver({
        animate: true,
        nextBtnText: next,
        prevBtnText: back,
        doneBtnText: done,
        closeBtnText: close
    });
    x.defineSteps([
        {
            element: '.guide-7',
            popover: {
                title: `<em>${guide7Title}</em>`,
                description: guide7Body,
                position: 'top'
            }
        },
        {
            element: '.guide-8',
            popover: {
                title: `<em></em>`,
                description: guide8Body,
                position: 'top'
            }
        },
        {
            element: '.guide-9',
            popover: {
                title: `<em></em>`,
                description: guide9Body,
                position: 'top'
            }
        },
        {
            element: '.guide-7',
            popover: {
                title: `<em></em>`,
                description: guide10Body,
                position: 'top'
            }
        }]);
    x.start();
};