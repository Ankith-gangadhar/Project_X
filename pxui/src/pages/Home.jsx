import { useEffect, useRef } from 'react';
import { gsap } from 'gsap';

const Home = () => {
  const containerRef = useRef(null);
  const headingRef = useRef(null);
  const subHeadingRef = useRef(null);
  const ctaButtonRef = useRef(null);

  useEffect(() => {
    const tl = gsap.timeline({ defaults: { ease: 'power3.out', duration: 1 } });
    tl.from(containerRef.current, { opacity: 0 })
      .from(headingRef.current, { y: -40, opacity: 0 }, '-=0.5')
      .from(subHeadingRef.current, { y: 20, opacity: 0 }, '-=0.5')
      .from(ctaButtonRef.current, { scale: 0.5, opacity: 0 }, '-=0.5');
  }, []);

  return (
    <div ref={containerRef} className="flex flex-col items-center justify-center min-h-screen bg-gradient-to-br from-blue-100 to-blue-300 text-gray-800">
      <h1 ref={headingRef} className="text-5xl font-bold mb-4">Welcome to ProductEngine</h1>
      <p ref={subHeadingRef} className="text-xl mb-8 text-center px-6">Manage your products effortlessly with our powerful backend system.</p>
      <button
        ref={ctaButtonRef}
        className="px-6 py-3 bg-blue-600 text-white rounded-2xl shadow-lg hover:bg-blue-700 transition-transform transform hover:scale-105"
      >
        Go to Product List
      </button>
    </div>
  );
};

export default Home;
